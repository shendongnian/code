    public class Form1 : Form
    {
        ...
        
        public void button_Click(...)
        {
            try
            {
                var myclass = new MyClass(@"C:\...some file");
                ...
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Can't find the file required");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }
    }
    public class MyClass
    {
       public MyClass(string path)
       {
           if(string.IsNullOrEmpty(path))
               throw new ArgumentNullException();
           if(!File.Exists(path))
               throw new FileNotFoundException();
           ...
       }
    }
