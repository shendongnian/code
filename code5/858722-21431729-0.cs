                    using (Stream s = response.GetResponseStream())
                    {
                        using (StreamReader sr = new StreamReader(s))
                        {
                            var jsonData = sr.ReadToEnd();
                            JsonTextReader reader = new JsonTextReader(new StringReader(jsonData));
                            string data="";
                            while (reader.Read())
                            {
                                if (reader.Value != null)
                                    data += reader.Value;
                            }
                            DataTable dt = (DataTable)JsonConvert.DeserializeObject(data, typeof(DataTable));
                            grd1.DataSource = dt;
                            grd1.DataBind();
                        }
                    }
                }
