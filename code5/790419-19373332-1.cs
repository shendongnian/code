    In the view 
        $(document).ready(function () {
            $("#hdnPkClientId").val('');
            $("#txt_Autocomplete").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "/Home/SearchClientDetail",
                        data: "{'searchtext':'" + document.getElementById('txt_Autocomplete').value + "'}",
                        dataType: "json",
                        success: function (data) {
                            response($.map(data.Data, function (item) {
    
                                return {
    
                                    label: item.Name,
                                    value: item.id,
                                    data: item
                                };
                            }));
                        },
                        error: function (xhr)
                        { }
                    });
                },
                select: function (event, ui) {
                    var detailArr = ui.item.label.split(',');
                    $("#txt_Autocomplete").val(detailArr[0]);
                    $("#hdnPkClientId").val(ui.item.data.Id);
                    $("#Evaluation_Anch").attr("href", "/Evaluation/Index?Client_ID=" + ui.item.data.Id);
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "/ClientHome/GetSelectedClientDetails",
                        data: "{'ClientId':'" + document.getElementById('hdnPkClientId').value + "'}",
                        dataType: "json",
                        success: function (data) {
                            $("#Client_Name").html(data.Info.Name);
                            $("#Client_Address").html(data.Info.Address);
                            $("#Client_OtherAddressDetails").html(data.Info.OtherAddressDetails);
                            $("#Client_DOB").html(data.Info.DOB);
                            $("#Client_Phone").html(data.Info.Phone);
                            $("Client_MobilePhone").html(data.Info.Mobile_Phone);
                            var DataDiv = "<table width='100' border='0' cellspacing='0' cellpadding='0'> <tr> <th class='head'>Date</th> <th class='head'>Document Type</th> <th class='head'>Provider</th> </tr>";
                            for (var iRow = 0; iRow < data.Info.Prev_Doc_List.length; iRow++) {
                                var temp = data.Info.Prev_Doc_List[iRow];
                                DataDiv += "<tr>";
                                DataDiv += "<td>" + temp.Created_Date + "</td>";
                                DataDiv += "<td><a id='" + temp.Page_ID + "' href='" + temp.RedirectAddress + "'>" + temp.Doc_type + "</a></td>";
                                DataDiv += "<td>" + temp.Provider + "</td>";
                                DataDiv += "</tr>";
                            }
                            DataDiv += "</table>";
                            $("#PreviousDocumentDiv").html(DataDiv);
                        },
                        error: function (xhr)
                        { }
                    });
                    return false;
                }
            });
        });
    
    In controller
    
       [HttpPost]
            public ActionResult GetSelectedClientDetails(string ClientId)
            {
                ProgressNotesService objService = new ProgressNotesService();
                var Client_Detail = objService.GetSelectedClient(Convert.ToInt32(ClientId));
                if (Client_Detail != null)
                {
                    Session["Client_ID"] = Client_Detail.Id;
                }
                return Json(new { Info = Client_Detail });
            }
    
    In Service
        public ClientDetailModel GetSelectedClient(int ClientID)
            {
                ClientDetailModel ClientDetail = new ClientDetailModel();
                List<PreviousDocuments> objDocsList = new List<PreviousDocuments>();
                using (DataContext DB = new DataContext())
                {
                    var Row = DB.tblreferralServices.Where(m => m.ID == ClientID).FirstOrDefault();
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
                                    Provider = "Cohens",
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
                                    Provider = "Cohens",
                                    Page_ID = Convert.ToString(Ref.ElementAt(iRow).ID)
                                });
                            }
                        }
                        ClientDetail.Prev_Doc_List = objDocsList;
                    }
    
                }
                return ClientDetail;
    
            }
    
    In model
    
    public class ClientDetailModel
        {
            public ClientDetailModel()
            {
                Prev_Doc_List = new List<PreviousDocuments>();
            }
            public string Name { get; set; }
            public string Id { get; set; }
            public string DOB { get; set; }
            public string Address { get; set; }
            public string OtherAddressDetails { get; set; }
            public string Phone { get; set; }
            public string Mobile_Phone { get; set; }
            public DateTime Client_DOB { get; set; }
            public List<PreviousDocuments> Prev_Doc_List { get; set; }
    
        }
        public class PreviousDocuments
        {
            public string Created_Date { get; set; }
            public string Doc_type { get; set; }
            public string Provider { get; set; }
            public string Page_ID { get; set; }
            public string RedirectAddress { get; set; }
        }
