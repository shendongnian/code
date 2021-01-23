    using System.Data;
	using System.Drawing;
	using System.Text;
	using System.Windows.Forms;
	using System.Runtime.InteropServices;
	namespace printdialog
	{
		public partial class Form1 : Form
		{
			Word.ApplicationClass WordApp;
			public Form1()
			{
				InitializeComponent();
			}
			private void button1_Click(object sender, EventArgs e)
			{
				//Create Word Instance
				WordApp = OpenWordApplication();
				 //Show Word
				WordApp.Visible = true;
				//Open a Word Doc
				OpenWordDocument(WordApp, "c:\\test.docx");
				DialogResult result = MessageBox.Show("Would you like to Print?", "PrintPreview", MessageBoxButtons.OKCancel);
				switch (result)
				{
					case DialogResult.OK:
						{
							WordApp.PrintPreview = true;
							break;
						}
					case DialogResult.Cancel:
						{
							CloseWordApplication(WordApp);
							break;
						}
				}
			}
			/// <summary>
			/// This method returns a Word.ApplicationClass Object.
			/// Tested with the Microsoft 9.0 Object Library ( COM )
			/// </summary>
			/// <returns>Word.ApplicationClass Object</returns>
			public static Word.ApplicationClass OpenWordApplication()
			{
				try
				{
					Word.ApplicationClass WordApp = new Word.ApplicationClass();
					return (WordApp);
				}
				catch (Exception e)
				{
					//show the user the error message
					MessageBox.Show(e.Message);
					return (null);
				}
			}
			/// <summary>
			/// This method returns a Word.Document Object from the File Location and loads it into the 
			/// Word.ApplicationClass Object. Basically it means it opens a previously saved word document. 
			/// Tested with the Microsoft 9.0 Object Library ( COM )
			/// </summary>
			/// <param name="WordApp">This is the Word.ApplicationClass Object. It is the Object that contains
			/// the Word Application</param>
			/// <param name="FileLocation">This is the File Location for the Word Document you would like to open.
			/// Note that this is the full long name of the File Location.</param>
			/// <returns>Word.Document Object</returns>
			public static Word.Document OpenWordDocument(Word.ApplicationClass WordApp, string FileLocation)
			{
				try
				{
					object j_FileName = FileLocation;
					object j_Visible = true;
					object j_ReadOnly = false;
					object j_NullObject = System.Reflection.Missing.Value;
					// Let's open the document
					Word.Document WordDoc = WordApp.Documents.Open(ref j_FileName,
					ref j_NullObject, ref j_ReadOnly, ref j_NullObject, ref j_NullObject,
					ref j_NullObject, ref j_NullObject, ref j_NullObject, ref j_NullObject,
					ref j_NullObject, ref j_NullObject, ref j_Visible);
					return (WordDoc);
				}
				catch (Exception e)
				{
					//show the user the error message
					MessageBox.Show(e.Message);
					return (null);
				}
			}
			/// <summary>
			/// This method closes the Word.ApplicationClass instance that is sent
			/// as a parameter. Releasing the COM Object by Marshal seems
			/// to properly dispose of the Object.
			/// Tested with the Microsoft 9.0 Object Library ( COM )
			/// </summary>
			/// <param name="WordApp"></param>
			public static void CloseWordApplication(Word.ApplicationClass WordApp)
			{
				try
				{
					object j_SaveChanges = false;
					object j_NullObject = System.Reflection.Missing.Value;
					WordApp.Quit(ref j_SaveChanges, ref j_NullObject, ref j_NullObject);
					Marshal.ReleaseComObject(WordApp);
					WordApp = null;
					System.GC.Collect();
					GC.WaitForPendingFinalizers();
				}
				catch (Exception e)
				{
					//show the user the error message
					MessageBox.Show(e.Message);
				}
			}
		}
	}
