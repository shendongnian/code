        public void SaveControls(List<Control> conts, Stream stream)
        {
            BinaryFormatter bf = new BinaryFormatter();
            List<Saver> sv = new List<Saver>();
            foreach (var item in conts)
            {
                //save the values to the saver object
                Saver saver = new Saver();
                saver.Type = item.GetType();
                saver.Location = item.Location;
                saver.Size = item.Size;
                saver.Text = item.Text;
                sv.Add(saver);
            }
            bf.Serialize(stream, sv);//serialize the list
        }
