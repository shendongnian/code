    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    namespace WPFPIVOT
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Pivot pivoted;
        PivotTableAdapters.GetUsageTableAdapter adapter;
        public MainWindow()
        {
            InitializeComponent();
            //this code is the same for WPF and FORMs
            pivoted = new Pivot();
            adapter = new PivotTableAdapters.GetUsageTableAdapter();
            adapter.Fill(pivoted.GetUsage);
            ///////////////////////////////////////////////////////////////
            
            
            datagrid.DataContext = pivoted;
        }
    }
    }
