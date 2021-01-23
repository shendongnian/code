    using System;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
      public class RecordSign
      {
        public int recordSign { get; set; }
        public string Description { get; set; }
      }
      public partial class Form1 : Form
      {
        int recordSign = 0;
        public Form1()
        {
          InitializeComponent();
          comboBox1.Items.Add(new RecordSign() { recordSign = 1, Description = "Record Sign 1" });
          comboBox1.Items.Add(new RecordSign() { recordSign = 2, Description = "Record Sign 2" });
          comboBox1.Items.Add(new RecordSign() { recordSign = 3, Description = "Record Sign 3" });
          comboBox1.Items.Add(new RecordSign() { recordSign = 4, Description = "Record Sign 4" });
          comboBox1.Items.Add(new RecordSign() { recordSign = 5, Description = "Record Sign 5" });
          comboBox1.Items.Add(new RecordSign() { recordSign = 6, Description = "Record Sign 6" });
          //Show the user-friendly text in the combobox
          comboBox1.DisplayMember = "Description";
          //Use the underlying value of the selected object for code logic
          comboBox1.ValueMember = "recordSign";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          //SelectedValue is an [object] so cast it to the type you need.
          var theRecordSign = comboBox1.SelectedItem as RecordSign;
          label1.Text = string.Format(
            "The chosen item is {0}, and its value is {1}.",
            theRecordSign.Description, theRecordSign.recordSign);
          recordSign = theRecordSign.recordSign;
        }
      }
    }
