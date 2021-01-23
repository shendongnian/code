        var isJunior = AJBG.CMS2.Sippcentre.AppCode.Functions.UserDetails.IsJunior();
        List<WebGridColumn> cols = new List<WebGridColumn>();
            cols.Add(new WebGridColumn { Header = "Client name", 
            ColumnName = "ClientName", CanSort = true, 
            Format = (item) => 
            String.Format("<a onclick=\"showPopUp()\" href=\"/Secure/Adviser/{2}/?ClientIdentifier={0}\">{1}</a>", item.Identifier, item.ClientName, (isJunior ? "Junior" : "Client")) });
    ...
