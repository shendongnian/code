    namespace ImpromptuExample
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                // Get the desired type
                Type typeObject = typeof(SampleLibrary.PublicClass).Assembly.GetType("SampleLibrary.SamplePrivateClass");
                // todo:  add error handling if typeObject is null
                // Create an instance
                object instance = Activator.CreateInstance(typeObject);
                ITest wrappedInstance = ImpromptuInterface.Impromptu.ActLike<ITest>(instance);
                MessageBox.Show(wrappedInstance.TestMethod(textBox1.Text));
            }
            public interface ITest
            {
                string TestMethod(string name);
            }
        }
    }
    namespace SampleLibrary
    {
        public class PublicClass
        {
        }
        class SamplePrivateClass
        {
            public string TestMethod(string name)
            {
                return string.Concat("Hello ", name);
            }
        }
    }
