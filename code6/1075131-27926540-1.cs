    tblCell = new HtmlTableCell();
    List<string> liEmailIdsForCC = new List<string>();
    if(some condition)
    {
    	liEmailIdsForCC.add("someitem");
    }
    
    HyperLink hpOwnerName = new HyperLink();
    hpOwnerName.Text += string.Format("(FullName)  ", "FullName");
    
    string listJSArray = string.Format("['{0}']", string.Join("', '", liEmailIdsForCC.ToArray());
    
    var onClick = string.Format("OnNameClick(document.GetElementById('{0}'), {1}); return false;", hpOwnerName.ClientID, listJSArray);
    hpOwnerName.Attributes.Add("onclick", onClick);
    tblCell.Controls.Add(hpOwnerName);
    
    // javascript code...
    function OnNameClick(source, list) {
        alert(list[0]);
    }
