    [Serializable]
    public class Vechicle
    {
        private int _Id;
        private String _Registration;
        public Vechicle()
        {
            _Id = 1;
            _Registration = "default name";
        }
        public Vechicle(int id, String registration)
        {
            Id = id;
            Registration = registration;
        }
        public override string ToString()
        {
            return Id.ToString() + " " + Registration;
        }
        #region getters/setters
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public String Registration
        {
            get { return _Registration; }
            set { _Registration = value; }
        }
        #endregion
    }
    private void button1_Click(object sender, EventArgs e)
        {
            List<Vechicle> vList = new List<Vechicle>()
            {
                new Vechicle(),
                new Vechicle(),
                new Vechicle{Id=2, Registration="hello"},
                new Vechicle{Id = 100, Registration="world"}
            };
            XmlSerializer SerializerObjVechicle = new XmlSerializer(vList.GetType());
            FileStream fs = new FileStream("d:\\test.xml", FileMode.OpenOrCreate);
            SerializerObjVechicle.Serialize(fs, vList);
        }
