    var tbAantal = null;
    
    private void assortiment_Load(object sender, EventArgs e)
        {
            string lastorder = "Select MAX(idorders) From orders";
    
    
            string query = "Select * From Product";
            var cmd = new MySqlCommand(lastorder, connection);
            cmd.CommandType = CommandType.Text;
            int orderid = Convert.ToInt32(cmd.ExecuteScalar());
            label1lblorderid.Text = orderid.ToString();
            var cmd2 = new MySqlCommand(query, connection);
            var da = new MySqlDataAdapter(cmd2);
            var ds = new DataSet();
            da.Fill(ds, "Image");
            int count = ds.Tables["Image"].Rows.Count;
            var y = 3;
    
            for (int i = 0; i < count; i++)
            {
                var data = (Byte[])(ds.Tables["Image"].Rows[i]["Image"]);
                var stream = new MemoryStream(data);
    
                //picture box creation
                var pbList = new PictureBox
                {
                    Name = "pic" + i,
                    Size = new Size(150, 150),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = Image.FromStream(stream)
                };
    
                //panel creation
                var tblPanelList = new TableLayoutPanel
                {
                    Name = "tblp" + i,
                    Size = new Size(380, 150),
                    Location = new System.Drawing.Point(219, y),
                    BackColor = Color.ForestGreen,
                    GrowStyle = TableLayoutPanelGrowStyle.AddColumns,
                    ColumnCount = 2
    
                };
    
                //other
                productid = Convert.ToInt32((ds.Tables["Image"].Rows[i]["idproduct"]).ToString());
    
                //Textbox: Aantal
                tbAantal = new TextBox { Size = new Size(107, 20), Name = "tbaantal" + productid};
    
    
                //label productid
                var lblproductid = new Label();
                 lblproductid.Text = productid.ToString();
    
    
                 //Button: Bestellen
                 var btnBestel = new Button();
                 btnBestel.Name = "bestel" + productid;
                 btnBestel.Text = "Bestellen";
                 btnBestel.Anchor = AnchorStyles.Right;
                 btnBestel.Click += btnBestel_Click;
    
                //Voeg controls toe
                this.panel.Controls.Add(pbList);
                this.Controls.Add(tblPanelList);
                tblPanelList.Controls.Add(naam);
                tblPanelList.Controls.Add(omschrijving);
                tblPanelList.Controls.Add(lblAantal);
                tblPanelList.Controls.Add(tbAantal);
                tblPanelList.Controls.Add(btnBestel,1,10);
                tblPanelList.Controls.Add(lblproductid);
    
    
                y = y + 156;
            }
    
        }
    
        void btnBestel_Click(object sender, EventArgs e)
        {
            MainForm frm_1 = new MainForm();
    
            var button = sender as Button;
            string btnname = button.Name.ToString();
            //btnname.Remove(1, 6);
            int orderid = Convert.ToInt32(label1lblorderid.Text);
            int aantal = Convert.ToInt32(tbAantal.Text);
            //MessageBox.Show(btnname.Remove(0,6));
            string query = "Insert Into orderproduct(idorder, idproduct, aantal) Values('" + orderid + "'" + productid +
                           "'" + aantal + "')";
            var cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }
