    <Window x:Class="FixNuGetProblemsInVs2015.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:FixNuGetProblemsInVs2015"
            mc:Ignorable="d"
            Title="Fix NuGet Packages problems in Visual Studio 2015 (By Eric Ouellet)" Height="350" Width="525">
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height="Auto"></RowDefinition>
                <RowDefinition Height="Auto"></RowDefinition>
                <RowDefinition Height="*"></RowDefinition>
                <RowDefinition Height="Auto"></RowDefinition>
            </Grid.RowDefinitions>
            
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="Auto"></ColumnDefinition>
                <ColumnDefinition Width="10"></ColumnDefinition>
                <ColumnDefinition></ColumnDefinition>
            </Grid.ColumnDefinitions>
    
            <TextBlock Grid.Row="0" Grid.Column="0">Root directory of projects</TextBlock>
            <Grid Grid.Row="0" Grid.Column="2">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition></ColumnDefinition>
                    <ColumnDefinition Width="Auto"></ColumnDefinition>
                </Grid.ColumnDefinitions>
    
                <TextBox Grid.Column="0" Name="DirProjects"></TextBox>
                <Button Grid.Column="1" VerticalAlignment="Bottom" Name="BrowseDirProjects" Click="BrowseDirProjectsOnClick">Browse...</Button>
            </Grid>
    
            <!--<TextBlock Grid.Row="1" Grid.Column="0">Directory of NuGet Packages</TextBlock>
            <Grid Grid.Row="1" Grid.Column="2">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition></ColumnDefinition>
                    <ColumnDefinition Width="Auto"></ColumnDefinition>
                </Grid.ColumnDefinitions>
    
                <TextBox Grid.Column="0" Name="DirPackages"></TextBox>
                <Button Grid.Column="1"  Name="BrowseDirPackages" Click="BrowseDirPackagesOnClick">Browse...</Button>
            </Grid>-->
    
            <TextBox Grid.Row="2" Grid.Column="0" Grid.ColumnSpan="3" Name="TxtLog" IsReadOnly="True"></TextBox>
            
            <Button Grid.Row="3" Grid.Column="0" Click="ButtonRevertOnClick">Revert back</Button>
            <Button Grid.Row="3" Grid.Column="2" Click="ButtonFixOnClick">Fix</Button>
        </Grid>
    </Window>
    
    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Forms;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Xml;
    using System.Xml.Linq;
    using Application = System.Windows.Application;
    using MessageBox = System.Windows.MessageBox;
    
    /// <summary>
    /// Applying recommanded modifications in section : "MSBuild-Integrated package restore vs. Automatic Package Restore"
    /// of : http://docs.nuget.org/Consume/Package-Restore/Migrating-to-Automatic-Package-Restore
    /// </summary>
    
    namespace FixNuGetProblemsInVs2015
    {
    	/// <summary>
    	/// Interaction logic for MainWindow.xaml
    	/// </summary>
    	public partial class MainWindow : Window
    	{
    		public MainWindow()
    		{
    			InitializeComponent();
    
    			DirProjects.Text = @"c:\prj";
    			// DirPackages.Text = @"C:\PRJ\NuGetPackages";
    		}
    
    		private void BrowseDirProjectsOnClick(object sender, RoutedEventArgs e)
    		{
    			FolderBrowserDialog dlg = new FolderBrowserDialog();
    			dlg.SelectedPath = DirProjects.Text;
    			if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
    			{
    				DirProjects.Text = dlg.SelectedPath;
    			}
    		}
    
    		//private void BrowseDirPackagesOnClick(object sender, RoutedEventArgs e)
    		//{
    		//	FolderBrowserDialog dlg = new FolderBrowserDialog();
    		//	dlg.SelectedPath = DirPackages.Text;
    		//	if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
    		//	{
    		//		DirPackages.Text = dlg.SelectedPath;
    		//	}
    		//}
    
    		// private string _dirPackages;
    
    		private void ButtonFixOnClick(object sender, RoutedEventArgs e)
    		{
    			DoJob(false);
    		}
    
    		private void ButtonRevertOnClick(object sender, RoutedEventArgs e)
    		{
    			DoJob(true);
    		}
    
    		private void DoJob(bool revert = false)
    		{
    			TxtLog.Text = "";
    
    			string dirProjects = DirProjects.Text;
    			// _dirPackages = DirPackages.Text;
    
    			if (!Directory.Exists(dirProjects))
    			{
    				MessageBox.Show("Projects directory does not exists: " + dirProjects);
    				return;
    			}
    
    			//if (!Directory.Exists(_dirPackages))
    			//{
    			//	MessageBox.Show("Packages directory does not exists: " + _dirPackages);
    			//	return;
    			//}
    
    			RecurseFolder(dirProjects, revert);
    		}
    
    		private void RecurseFolder(string dirProjects, bool revert = false)
    		{
    			if (revert)
    			{
    				Revert(dirProjects);
    			}
    			else
    			{
    				FixFolder(dirProjects);
    			}
    
    			foreach (string subfolder in Directory.EnumerateDirectories(dirProjects))
    			{
    				RecurseFolder(subfolder, revert);
    			}
    		}
    
    		private const string BackupSuffix = ".fix_nuget_backup";
    		
    		private void Revert(string dirProject)
    		{
    			foreach (string filename in Directory.EnumerateFiles(dirProject))
    			{
    				if (filename.ToLower().EndsWith(BackupSuffix))
    				{
    					string original = filename.Substring(0, filename.Length - BackupSuffix.Length);
    					if (File.Exists(original))
    					{
    						File.Delete(original);											
    					}
    					File.Move(filename, original);
    					Log("File reverted: " + filename + " ==> " + original);
    				}
    			}
    		}
    
    		private void FixFolder(string dirProject)
    		{
    			BackupFile(System.IO.Path.Combine(dirProject, "nuget.targets"));
    			BackupFile(System.IO.Path.Combine(dirProject, "nuget.exe"));
    
    			foreach (string filename in Directory.EnumerateFiles(dirProject))
    			{
    				if (filename.ToLower().EndsWith(".csproj"))
    				{
    					FromProjectFileRemoveNugetTargets(filename);
    				}
    			}
    		}
    
    		private void BackupFile(string path)
    		{
    			if (File.Exists(path))
    			{
    				string backup = path + BackupSuffix;
                    if (!File.Exists(backup))
    				{
    					File.Move(path, backup);
    					Log("File backup: " + backup);
    				}
    				else
    				{
    					Log("Project has already a backup: " + backup);
    				}
    			}
    		}
    
    		private void FromProjectFileRemoveNugetTargets(string prjFilename)
    		{
    			XDocument xml = XDocument.Load(prjFilename);
    
    			List<XElement> elementsToRemove = new List<XElement>();
    			
    			foreach (XElement element in xml.Descendants())
    			{
    				if (element.Name.LocalName == "Import")
    				{
    					var att = element.Attribute("Project");
    					if (att != null)
    					{
    						if (att.Value.Contains("NuGet.targets"))
    						{
    							elementsToRemove.Add(element);
    						}
    					}
    				}
    
    				if (element.Name.LocalName == "Target")
    				{
    					var att = element.Attribute("Name");
    					if (att != null && att.Value == "EnsureNuGetPackageBuildImports")
    					{
    						elementsToRemove.Add(element);
    					}
    				}
    			}
    
    			if (elementsToRemove.Count > 0)
    			{
    				elementsToRemove.ForEach(element => element.Remove());
    				BackupFile(prjFilename);
    				xml.Save(prjFilename);
    				Log("Project updated: " + prjFilename);
    			}
    		}
    
    		private void Log(string msg)
    		{
    			TxtLog.Text += msg + "\r\n";
    		}
    
    	}
    }
