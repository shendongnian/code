    while (dr.Read())
                {
                    object serialNumber = dr["product_serial_number"];
                    lbBeltFinalBuild.Items.Add(serialNumber.ToString());
                }
                if (lbBeltFinalBuild.Items.Count == 0)
                {
                    lbBeltFinalBuild.Items.Add("No Data");
                    lblBeltFinalBuild.Text = "Total 0";
                }
                else
                {
                    BeltFinalTotal = lbBeltFinalBuild.Items.Count;
                    lblBeltFinalBuild.Text = "Total " + BeltFinalTotal.ToString();
                }
