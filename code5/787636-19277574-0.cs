    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<mustFiles> mustTxtFiles = new List<mustFiles>();
            
            mustFiles mf = new mustFiles();
            mf.filename = "filenameA";
            mf.description = "descriptionA";
            textboxTool tbt = new textboxTool();
            tbt.defaultText = "defaultTextA";
            tbt.browseButton = true;
            tbt.multiLine = true;
            mf.mustTools.Add(tbt);
            mustTxtFiles.Add(mf);
            mf = new mustFiles();
            mf.filename = "filenameB";
            mf.description = "descriptionB";
            tbt = new textboxTool();
            tbt.defaultText = "defaultTextB";
            tbt.browseButton = true;
            tbt.multiLine = true;
            mf.mustTools.Add(tbt);
            mustTxtFiles.Add(mf);
            // serialize it
            XmlSerializer serializer = new XmlSerializer(typeof(List<mustFiles>), new Type[] {typeof(fileTools), typeof(textboxTool), typeof(comboboxTool)});
            string xmlFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MustFiles.xml");
            using (System.IO.FileStream stream = File.OpenWrite(xmlFile))
            {
                serializer.Serialize(stream, mustTxtFiles);
            }
            // Why not just this?
            // deserialize it 
            //List<mustFiles> mustTry;
            //using (FileStream stream = File.OpenRead(xmlFile))
            //{
            //    mustTry = (List<mustFiles>)serializer.Deserialize(stream);
            //}
            // deserialize it with generic function:
            List<mustFiles> mustTry = loadXml<List<mustFiles>>(xmlFile, new Type[] { typeof(fileTools), typeof(textboxTool), typeof(comboboxTool) });
        }
        public T loadXml<T>(string xmlFileName, Type[] additionalTypes)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T), additionalTypes);
            using (FileStream stream = File.OpenRead(xmlFileName))
            {
                return (T)serializer.Deserialize(stream);
            }
        }
    }
