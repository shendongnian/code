            var regex = new Regex(@"^poke__\d+_$");
            var propertyDictionary = ResourceHelper.GetStaticPropertiesOfType<Image>(typeof(Properties.Resources)).Where(p => regex.IsMatch(p.Name)).ToDictionary(p => p.Name);
            foreach (var property in propertyDictionary.Values)
            {
                pictureBox1.Image = (Image)property.GetValue(null, null);
            }
