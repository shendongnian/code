          while (reader.Read())
            {
                int sira = listView1.Items.Count;
                listView1.Items.Add("Put some text here"); // <- Add a new item
                listView1.Items[sira].SubItems.Add(reader.GetString("id"));
                listView1.Items[sira].SubItems.Add(reader.GetString("ad"));
                listView1.Items[sira].SubItems.Add(reader.GetString("soyad"));
                listView1.Items[sira].SubItems.Add(reader.GetString("evrakulastimi"));
                listView1.Items[sira].SubItems.Add(reader.GetString("basvurusonuclandimi"));
            }
