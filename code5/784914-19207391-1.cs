            while (reader.Read())
            {
                ProfielModels temp = new ProfielModels();
                temp.Voornaam = reader["Voornaam"].ToString();
                temp.Tussenvoegsel = reader["Tussenvoegsel"].ToString();
                temp.Achternaam = reader["Achternaam"].ToString();
                temp.Adres = reader["Adres"].ToString();
                temp.Postcode = reader["Postcode"].ToString();
                temp.Plaats = reader["Plaats"].ToString();
                temp.Land = reader["Land"].ToString();
                temp.Geboortedatum = reader["Geboortedatum"].ToString();
                temp.Telefoonnummer = reader["Telefoonnummer"].ToString();
                temp.Mobielnummer = reader["Mobielnummer"].ToString();
                temp.Email = reader["Email"].ToString();
                ListModal.Add(temp);
            }
