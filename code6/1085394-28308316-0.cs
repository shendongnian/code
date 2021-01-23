     if (dr.Read())
                {
                    while (dr.Read())
                    {
                        object serialNumber = dr["product_serial_number"];
                        lbBeltFinalBuild.Items.Add(serialNumber.ToString());
                    }
                    // Assign totals to variables and display them in a label control
                    BeltFinalTotal = lbBeltFinalBuild.Items.Count;
                    lblBeltFinalBuild.Text = "Total " + BeltFinalTotal.ToString();
                }
                else
                {
                    lbBeltFinalBuild.Items.Add("No Data");
                    lblBeltFinalBuild.Text = "Total 0";
                }
