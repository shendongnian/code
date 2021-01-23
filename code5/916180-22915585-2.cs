        public List<Control> LoadControls(Stream stream)
        {
            BinaryFormatter bf = new BinaryFormatter();
            List<Saver> sv =(List<Saver>) bf.Deserialize(stream);
            List<Control> conts = new List<Control>();
            foreach (var item in sv)
            {
                //create an object at run-time using it's type
                Control c = (Control)Activator.CreateInstance(item.Type);
                //reload the saver values into the control object
                c.Location = item.Location;
                c.Size = item.Size;
                c.Text = item.Text;
                conts.Add(c);
            }
            return conts;
        }
