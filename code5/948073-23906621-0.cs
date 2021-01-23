            if (!IsPostBack)
            {
            
            SqlConnection con = new SqlConnection(constr);
            string strquery = "select * from insertuser Where companyname='Prhemnath'";
            SqlCommand cmdd = new SqlCommand();
            cmdd.CommandType = CommandType.Text;
            cmdd.CommandText = strquery;
            cmdd.Connection = con;
            try
            {
                con.Open();
                SqlDataReader sdr = cmdd.ExecuteReader();
                while (sdr.Read())
                {
                    txtcompanyname.Text = sdr["companyname"].ToString();
                    ddtypeofcmpy.SelectedValue = sdr["typeofcompany"].ToString();
                    txtauthname.Text = sdr["authorizedperson"].ToString();
                    txtauthdesg.Text = sdr["authorizedperdesig"].ToString();
                    txtregoffice.Text = sdr["registeredoffaddress"].ToString();
                    txtcorroffice.Text = sdr["correspondanceaddress"].ToString();
                    txtll1.Text = sdr["landline1"].ToString();
                    txtll2.Text = sdr["landline2"].ToString();
                    txtmob1.Text = sdr["mobile1"].ToString();
                    txtmob2.Text = sdr["mobile2"].ToString();
                    txtfax.Text = sdr["email"].ToString();
                    txtemail.Text = sdr["email"].ToString();
                    txtweb.Text = sdr["website"].ToString();
                    txtusername.Text = sdr["username"].ToString();
                    txtnumempcp.Text = sdr["empwithcp"].ToString();
                    txtnonumempcp.Text = sdr["empwocp"].ToString();
                    txtchnpan.Text = sdr["newCHAPAN"].ToString();
                    txtchalicence.Text = sdr["newCHAlicence"].ToString();
                    txtchptreg.Text = sdr["CHPTregnumber"].ToString();
                    txtchptvalid.Text = sdr["CHPTvalidity"].ToString();
                    chkaurangabad.Checked = Convert.ToBoolean(sdr["aurangabad"]);
                    chkbangalore.Checked = Convert.ToBoolean(sdr["bangalore"]);
                    chkchn.Checked = Convert.ToBoolean(sdr["chennai"]);
                    chklcochin.Checked = Convert.ToBoolean(sdr["cochin"]);
                    chkdelhi.Checked = Convert.ToBoolean(sdr["delhi"]);
                    chkgoa.Checked = Convert.ToBoolean(sdr["goa"]);
                    chkhyd.Checked = Convert.ToBoolean(sdr["hyderabad"]);
                    chkindore.Checked = Convert.ToBoolean(sdr["kakinada"]);
                    chkkandla.Checked = Convert.ToBoolean(sdr["kolkatta"]);
                    chkludhiana.Checked = Convert.ToBoolean(sdr["ludhiana"]);
                    chkmangalore.Checked = Convert.ToBoolean(sdr["mangalore"]);
                    chkmumbai.Checked = Convert.ToBoolean(sdr["bombay"]);
                    chknagpur.Checked = Convert.ToBoolean(sdr["nagpur"]);
                    chknashik.Checked = Convert.ToBoolean(sdr["nashik"]);
                    chkpatna.Checked = Convert.ToBoolean(sdr["patna"]);
                    chkpune.Checked = Convert.ToBoolean(sdr["pune"]);
                    chkrajasthan.Checked = Convert.ToBoolean(sdr["rajasthan"]);
                    chkthiruvanthapuram.Checked = Convert.ToBoolean(sdr["trivandram"]);
                    chktuticorin.Checked = Convert.ToBoolean(sdr["tutucorin"]);
                    chkvisakhapatanam.Checked = Convert.ToBoolean(sdr["vishkapattinam"]);
                    chkconsolidation.Checked = Convert.ToBoolean(sdr["consolidation"]);
                    chkCHA.Checked = Convert.ToBoolean(sdr["CHBA"]);
                    cnkFF.Checked = Convert.ToBoolean(sdr["FF"]);
                    chkhandling.Checked = Convert.ToBoolean(sdr["handlingliveani"]);
                    chkPE.Checked = Convert.ToBoolean(sdr["handlingPA"]);
                    chkIATA.Checked = Convert.ToBoolean(sdr["IATAagents"]);
                    chkerecplant.Checked = Convert.ToBoolean(sdr["erectionofplant"]);
                    chktransp.Checked = Convert.ToBoolean(sdr["liquidtrans"]);
                    chkMTO.Checked = Convert.ToBoolean(sdr["MTOagents"]);
                    chkODC.Checked = Convert.ToBoolean(sdr["ODCtran"]);
                    chkImport.Checked = Convert.ToBoolean(sdr["projimport"]);
                    chkhandequip.Checked = Convert.ToBoolean(sdr["supplycranes"]);
                    chkbulkcargo.Checked = Convert.ToBoolean(sdr["bulkcargo"]);
                    chkcargo.Checked = Convert.ToBoolean(sdr["containercargo"]);
                    chkware.Checked = Convert.ToBoolean(sdr["warehousing"]);
                }
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            }
