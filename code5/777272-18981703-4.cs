    public void getchildCntrl(Panel pnl,ComboBox cmbb)
        {
    //// your code.....
                    //combobox create
                    var cmb = new ComboBox();
                    cmb.SelectedIndexChanged+=new EventHandler(cmb_SelectedIndexChanged);
    // remaining code
                    cmb.Visible = true;
                    pnl.Controls.Add(cmb);
                }
            }
        }
