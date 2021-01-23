       private void button1_Click(object sender, EventArgs e)
            {
                Image tempImage;
                using (var conn = new SqlConnection("myconnectionstring"))
                {
                    conn.Open();
                    using (
                        var cmd = new SqlCommand("SprocToGetImageBytes", conn) {CommandType = CommandType.StoredProcedure})
                    {
                        using (var rdr = cmd.ExecuteReader())
                        {
                            var buffer = (byte[])rdr[0];
                            using (var ms = new MemoryStream(buffer))
                            {
                                tempImage = Image.FromStream(ms); //theres your image.
                                pictureBox1.Image = tempImage;
                                pictureBox1.Refresh();
                            }
                        }
                    }
                }
            }
