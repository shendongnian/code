        public ClientDetailModel GetSelectedClient(int ClientID)
            {
                ClientDetailModel ClientDetail = new ClientDetailModel();
                List<PreviousDocuments> objDocsList = new List<PreviousDocuments>();
                using (DataContext DB = new DataContext())
                {
                    var Row = DB.tbl.Where(m => m.ID == ClientID).FirstOrDefault();
                    if (Row != null)
                    {
                        ClientDetail.Id = Row.ID.ToString();
                        ClientDetail.Name = Row.First_Name + " " + Row.Last_Name;
                        ClientDetail.Address = Row.Address;
                        ClientDetail.Client_DOB = (DateTime)Row.DOB;
                        ClientDetail.DOB = ClientDetail.Client_DOB.ToString("MM/dd/yyyy");
                        ClientDetail.OtherAddressDetails = (Row.City == "" || Row.City == null ? "N/A" + " " + "," : Row.City + " ,") + (Row.State == "" || Row.State == null ? "N/A" + " " + "," : Row.State + " ,") + (Row.ZipCode == "" || Row.ZipCode == null ? "N/A" : Row.ZipCode);
                        ClientDetail.Phone = Row.Phone;
                        ClientDetail.Mobile_Phone = Row.OtherContact_Phone;
                        var ProgressNoteRecords = DB.ProgressNotes.Where(m => m.FkReferralID == ClientID).ToList();
                        if (ProgressNoteRecords.Count() > 0)
                        {
                            for (int iRow = 0; iRow < ProgressNoteRecords.Count(); iRow++)
                            {
                                objDocsList.Add(new PreviousDocuments
                                {
                                    Created_Date = Convert.ToString(ProgressNoteRecords.ElementAt(iRow).Created_Date),
                                    Doc_type = "Progress Note",
                                    Provider = " blah blah",
                                    Page_ID = Convert.ToString(ProgressNoteRecords.ElementAt(iRow).Id),
                                    RedirectAddress = "../ProgressNote/Add?ProgressNote_ID=" + Convert.ToString(ProgressNoteRecords.ElementAt(iRow).Id)
    
                                });
                            }
                        }
                        var Ref = DB.tblrefServices.Where(m => m.ID == ClientID).ToList();
                        if (Ref.Count > 0)
                        {
                            for (int iRow = 0; iRow < Ref.Count(); iRow++)
                            {
                                objDocsList.Add(new PreviousDocuments
                                {
                                    Created_Date = Convert.ToString(Ref.ElementAt(iRow).First_Name),
                                    Doc_type = "Referral Service",
                                    Provider = "blah blah",
                                    Page_ID = Convert.ToString(Ref.ElementAt(iRow).ID)
                                });
                            }
                        }
                        ClientDetail.Prev_Doc_List = objDocsList;
                    }
    
                }
                return ClientDetail;
    
            }
    
