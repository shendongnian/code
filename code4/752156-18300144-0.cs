    <table>
        <tr>
            <td class="">Name</td>
            <td><asp:Label ID="Name" runat="server" /></td>
        </tr>
    </table>
 
    using (SPSite site = new SPSite(webUrl))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        SPList list = web.Lists.TryGetList(listName);
                        if (list != null)
                        {
                            SPQuery query = new SPQuery();
                            query.Query = "<Where><Eq><FieldRef Name='PatientID' /><Value Type='Number'>" + PatientID + "</Value></Eq></Where>";
    
                            SPListItemCollection items = list.GetItems(query);
                            if (items != null)
                            {
                                SPListItem item = items[0];
                                Name.Text = item["Name"].ToString();
    
                            }
                        }
                    }
