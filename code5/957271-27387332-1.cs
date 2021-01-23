            private async void  PrintEstimate()
        {
            // BUILD ESTIMATE WHICH IS AN HTML PAGE BECAUSE THEIR DID NOT APPEAR TO BE
            // A WAY TO REALLY BUILD REPORTS FOR WINRT APPLICATIONS AT THIS POINT WITHOUT
            // PURCHASING THRIRD PARTY TOOLS.
            // Validate Estimate
            // Are their values in the estimate list?
            if (this.listServices.Items.Count < 1)
            {
                MessageDialog msgDialog = new MessageDialog("You must first add services before you can print an estimate.");
                // Show the message dialog
                await msgDialog.ShowAsync();
                return;
            }
            if (string.IsNullOrEmpty(this.txtTotal1.Text))
            {
                
                MessageDialog msgDialog = new MessageDialog("You must first add the total before you can print an estimate.");
                // Show the message dialog
                await msgDialog.ShowAsync();
                return;
            }
            var strAppPath = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, @"EstimateReport\NewAPEMiniLogo.png");
            var dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "APE.db");
            // ESTIMATE VARIABLES
            string dtDateOfEstimate = Convert.ToString(this.dateEstimate.Date.ToString("MM/dd/yyyy"));
            string strCustomerName = null;
            string strCustomerAddress = null;
            string strCustomerPhone = null;
            string strCustomerNotes = null;
            double totalCost = Convert.ToDouble(this.txtTotal1.Text);
            double taxes = .08 * totalCost;
            string strEstimateNote = this.txtNotes.Text;
            string base64;
            // THE WINRT Environment is very limited as far as accessing local resources... and from all that I have found
            // Is purposely limited in allowing this to be done... thus here I am converting the image to a base64 string
            //StorageFolder appFolder = ApplicationData.Current.LocalFolder;
            StorageFolder appFolder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("EstimateReport");
            StorageFile imageFile = await appFolder.GetFileAsync("NewAPEMiniLogo.png");
            using (var stream = await imageFile.OpenAsync(FileAccessMode.Read))
            {
                var reader = new DataReader(stream.GetInputStreamAt(0));
                var bytes = new byte[stream.Size];
                await reader.LoadAsync((uint)stream.Size);
                reader.ReadBytes(bytes);
                base64 = Convert.ToBase64String(bytes);
            }
            
            // IF NEW ESTIMATE
            if (currentEstimateID == 0)
            {
                // CREATE/ INSERT NEW ESTIMATE                
                using (var db = new SQLite.SQLiteConnection(dbPath))
                {
                    db.CreateTable<APE_Painting_App.DataAccess.Estimate>();
                    db.RunInTransaction(() => { db.Insert(new DataAccess.Estimate() { CustomerID = currentCustomerID, EstimateDate = Convert.ToDateTime(dtDateOfEstimate), TotalCost = totalCost, EstimateNotes = strEstimateNote }); });
                    string sql = "SELECT last_insert_rowid()";
                    currentEstimateID = db.ExecuteScalar<int>(sql);
                    db.Close();
                }
            }
            else
            {
                // ELSE UPDATE CURRENT ESTIMATE
                dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "APE.db");
                using (var db = new SQLite.SQLiteConnection(dbPath))
                {
                    // THE ONLY THREE ITEMS THAT SHOULD BE CHANGEABLE AT THE ESTIMATE LEVEL ARE TOTAL COST, ESTIMATE NOTES AND ESTIMATE DATE.
                    var objEstimate = db.Table<Estimate>().Where(c => c.EstimateID == currentEstimateID).Single();
                    objEstimate.EstimateDate = Convert.ToDateTime(dtDateOfEstimate);
                    objEstimate.TotalCost = totalCost;
                    objEstimate.EstimateNotes = strEstimateNote;
                    objEstimate.JobAwarded = this.chkJobAwarded.IsChecked.Value;
                    db.Update(objEstimate);
                    db.Close();
                }
            }
            // GET CUSTOMER VALUES
            using (var db = new SQLite.SQLiteConnection(dbPath))
            {
                var objCustomer = db.Table<Customer>().Where(c => c.CustomerID == currentCustomerID).Single(); 
                strCustomerName = objCustomer.FirstName + " " + objCustomer.LastName;
                strCustomerAddress = objCustomer.Address1 + " " + objCustomer.Address2 + " " + objCustomer.City + " " + objCustomer.State + " " + objCustomer.Zip;
                strCustomerPhone = objCustomer.Phone1;
                strCustomerNotes = objCustomer.CustomerNote;
     
               db.Close();
            }
            StringBuilder sb = new StringBuilder();
            
            sb.Append(@"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">" + "\r\n");
            sb.Append(@"<!-- saved from url=(0016)http://localhost-->" + "\r\n");
            sb.Append(@"<html xmlns=""http://www.w3.org/1999/xhtml"">" + "\r\n");
            sb.Append(@"<head>" + "\r\n");
            sb.Append(@"<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />" + "\r\n");
            sb.Append(@"<title>Service Estimate: A.P.E. Painting Inc.</title>" + "\r\n");
            sb.Append(@"<style type='text/css' media='print'>.printbutton {visibility: hidden; display: none;}</style>" + "\r\n");
            sb.Append(@"<style type=""text/css"">" + "\r\n");
            sb.Append(@"body{font-family:""Palatino Linotype"", ""Book Antiqua"", Palatino, serif;}" + "\r\n");
            sb.Append(@"#printablePage{ width:1000px; height:1300px; padding: 30px; position:relative; left:10px; top:10px; }" + "\r\n");
            sb.Append(@"#headTitle{ font-size:24px;  position:absolute; left:225px; top:15px;}" + "\r\n");
            sb.Append(@"#reportName{ font-size:30px; position:absolute; left:850px; top:10px; color:#FFA61B;}" + "\r\n");
            sb.Append(@"#companyBlock{ position:absolute; top:45px; left:225px;}" + "\r\n");
            sb.Append(@"#footerNote{ font-size:16px;position:absolute; width:500px; left:150px; top:1135px; font-weight:bold;}" + "\r\n");
            sb.Append(@"#logo{ position:absolute; top:20px; left:20px;}" + "\r\n");
            sb.Append(@".customertable{font-size:14px;color:#333333;width:94%;border-width: 1px;border-color:#ebab3a;border-collapse:collapse;position:absolute;top:200px;}" + "\r\n");
            sb.Append(@".apetable {font-size:14px;color:#333333;width:94%;border-width: 1px;border-color: #ebab3a;border-collapse: collapse; position:absolute; top: 350px;}" + "\r\n");
            sb.Append(@".apetableB{font-size:14px;color:#333333;width:94%;border-width: 1px;border-color: #ebab3a;border-collapse: collapse; position:absolute; top: 1125px;}" + "\r\n");
            sb.Append(@".apetableC{font-size:10px;color:#333333;width:94%;border-width: 1px;border-color: #ebab3a;border-collapse: collapse; position:absolute; top: 1236px;}" + "\r\n");
            sb.Append(@"th {font-size:16px;background-color:#FFA61B;border-width: 1px;padding: 8px;border-style: solid;border-color: #ebab3a;text-align:left; color:#fff;}" + "\r\n");
            sb.Append(@"tr {background-color:#FFF;}" + "\r\n");
            sb.Append(@"td {font-size:12px;border-width: 1px;padding: 8px;border-style: solid;border-color: #FFA61B; height:20px;}" + "\r\n");
            sb.Append(@".apetable tr:hover {background-color:#FFA61B;}" + "\r\n");
            sb.Append(@".col1{width:80%;}" + "\r\n");
            sb.Append(@".col1B{width:80%; border-left-color:#FFF; border-bottom-color:#FFF; border-top:none; text-align:right; font-size:16px; font-weight:bold;}" + "\r\n");
            sb.Append(@".col1C{width:50%; font-size:12px; }" + "\r\n");
            sb.Append(@".col2{width:20%; }" + "\r\n");
            sb.Append(@"</style>" + "\r\n");
            sb.Append(@"<script>function printDiv() {" + "\r\n");
            sb.Append(@" window.focus(); window.print(); } " + "\r\n");
            sb.Append(@"</script>" + "\r\n");
            sb.Append(@"</head>" + "\r\n");
            sb.Append(@"<body>" + "\r\n");
            sb.Append(@"<input style = 'position:absolute; width: 150px; height:75px; z-index: 99;' type='button' class='printbutton' onClick='printDiv()' value='Print Report' />" + "\r\n");
            sb.Append(@"<div id=""printablePage"">" + "\r\n");
            sb.Append(@"<h1 id=""headTitle"">A.P.E. Painting Inc.</h1>" + "\r\n");
            sb.Append(@"<h1 id=""reportName"">" + this.pageTitle.Text + @"</h1>" + "\r\n");
            sb.Append(@"<h3 id=""companyBlock"">" + "\r\n");
            sb.Append(@"30809 NE Coyote Lane <br/>" + "\r\n");
            sb.Append(@"Yacolt, WA 98675 <br/>" + "\r\n");
            sb.Append(@"(360) 263-7699 <br/>" + "\r\n");
            sb.Append(@"<em> WA State Lic. &amp; Reg. #APEPAI*011QQ</em>" + "\r\n");
            sb.Append(@"</h3>" + "\r\n");
            //sb.Append(@"<img id= ""logo"" src=""" + strAppPath + @""" width=""197"" height=""148"" alt=""APE LOGO"" />" + "\r\n");
            sb.Append("<img src=\"data:image/png;base64,");
            sb.Append(base64);
            sb.Append("\" />");
      
            sb.Append(@"<table class=""customertable"" border=""1"">" + "\r\n");
            sb.Append(@"<tr><td> <strong>Estimate Date:</strong> " + dtDateOfEstimate + "   |   <strong>Customer:</strong> " + strCustomerName + "   |   <strong>Customer Phone:</strong> " + strCustomerPhone + " </td></tr>" + "\r\n");
            sb.Append(@"<tr><td> <strong>Customer Address:</strong> " + strCustomerAddress + " </td></tr>" + "\r\n");
            sb.Append(@"<tr><td> <strong>Project Notes:</strong> " + strEstimateNote + " </td></tr>" + "\r\n");
            sb.Append(@"</table>" + "\r\n");
            sb.Append(@"<table class=""apetable"" border=""1"">" + "\r\n");
            sb.Append(@"<tr><th class=""col1"">Services</th></tr>" + "\r\n");
            // Get Count of Estimate Items
            int intEstimateLines = this.listServices.Items.Count;
            // DELETE ALL PREVIOUS SERVICE LINES FOR THIS ESTIMATE IF ANY EXIST
            using (var db = new SQLite.SQLiteConnection(dbPath))
            {
                SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbPath);
                var query = conn.Table<EstimateDetails>().Where(x => x.EstimateID == currentEstimateID);
                var result = await query.ToListAsync();
                foreach (var item in result)
                {
                    // FIRST DELETE ALL ESTIMATE DETAIL RECORDS
                    // GET CURRENT ESTIMATE ID
                    int estimateDetailID = item.EstimateDetailID;
                    try
                    {
                        db.Execute("DELETE FROM EstimateDetails WHERE EstimateDetailID = ?", estimateDetailID);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            // LOOP 20 Times TO CREATE THE STATIC LINES IN THE INVOICE WHETHER THEIR IS A SERVICE OR NOT. ALSO:
            // INSERT SERVICES/ LOOP THORUGH SERVICES ARRAY TO OBTAIN VALUES
            for (int i = 0; i < 20; i++)
            {
                // INSERT RECORD TO DATABASE IF NECESSARY FIELDS HAVE VALUE
                if (i >= intEstimateLines)
                {
                    // NO SERVICES OR COST JUST ADD EMPTY SPACE ON REPORT
                    sb.Append(@"<tr><td class=""col1""> </td></tr>" + "\r\n");
                }
                else
                {
                    this.listServices.SelectedIndex = i;
                    string currentValue = this.listServices.SelectedItem.ToString();
                    using (var db = new SQLite.SQLiteConnection(dbPath))
                    {
                        db.CreateTable<APE_Painting_App.DataAccess.EstimateDetails>();
                        db.RunInTransaction(() => { db.Insert(new DataAccess.EstimateDetails() { EstimateID = currentEstimateID, EstimateLineItem = currentValue }); });
                        // FILL REPORT WITH CORRESPONDING VALUES
                        sb.Append(@"<tr><td class=""col1""> " + currentValue + @" </td></tr>" + "\r\n");
                    }
                }
            }
            sb.Append(@"</table>" + "\r\n");
            sb.Append(@"<table class=""apetableB"" border=""1"">" + "\r\n");
            sb.Append(@"<tr><td class=""col1B"">Sub Total:</td><td class=""col2"" style="" text-align:Left;"">" + String.Format("{0:C}", totalCost) + @" </td></tr>" + "\r\n");
            sb.Append(@"<tr><td class=""col1B""> Taxes:</td><td class=""col2"" style="" text-align:Left;""> " + String.Format("{0:C}", taxes) + @" </td></tr>" + "\r\n");
            sb.Append(@"<tr><td class=""col1B"">Total:</td><td class=""col2"" style="" text-align:Left;"">" + String.Format("{0:C}", (taxes + totalCost)) + @" </td></tr>" + "\r\n");
            sb.Append(@"</table>" + "\r\n");
            sb.Append(@"<div id=""footerNote"">We propose to furnish material and labor - complete in accordance with the above specifications, for the sum of:<br /><br />Method of Payment:</div>" + "\r\n");
            sb.Append(@"<table class=""apetableC"" border=""1"">" + "\r\n");
            sb.Append(@"<tr>" + "\r\n");
            sb.Append(@"<td class=""col1C"">All material is guaranteed to be as specified. All work to be completed in a workman like manner according to standard practices. Any alteration or deviation from above specifications involving extra costs will be executed only upon written orders, and will become an extra charge over and above the estimate. All agreements contingent upon strikes, accidents or delays beyond our control. Owner to carry fire, tornado and other necessary insurance. Our workers are fully covered by Workmans Compensation Insurance. </td>" + "\r\n");
            sb.Append(@"<td class=""colC""><span style=""font-weight:bold;"">Acceptance of Proposal- </span>The above prices, specifications and conditions are satisfactory and are hereby accepted. Your are authorized to do the work as specified. Payment will be made as outlined above. <span style=""font-weight:bold;"">Date of Acceptance:_______________________  </span><br /><br /><br />   <span style=""font-weight:bold;"">Signature:________________________________________________________________________</span></td></tr>" + "\r\n");
            sb.Append(@"</table>" + "\r\n");
            sb.Append(@"</div>" + "\r\n");
            sb.Append(@"<body>" + "\r\n");
            sb.Append(@"</body>" + "\r\n");
            sb.Append(@"</html>" + "\r\n");
            // Create a file in local storage
            var folder = ApplicationData.Current.LocalFolder;
            var file = await folder.CreateFileAsync("APE_Printable_Estimate.html", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, sb.ToString());
            string strURL = @"file:/// " + file.Path.ToString();         //      
            // OPEN FILE
            await Windows.System.Launcher.LaunchFileAsync(file);
        }
