    var ringtones = Live.Ringtones;
    
    if (cbSeller.SelectedValue!= null)
        ringtones = ringtones.Where(x=> x.Property.SellerID 
                                         == (int)cbSeller.SelectedValue);
    
    if (cbProperty.SelectedValue!= null)
        ringtones = ringtones.Where(x=> x.PropertyID 
                                         == (int)cbProperty.SelectedValue);
    
    if(!string.IsNullOrEmpty(tbContentID.Text))
        ringtones.Where(x=> x.RingtoneID == ContentID)
    
    if(!string.IsNullOrEmpty(tbContentName.Text) )
        ringtones.Where(x => || x.RingtoneName == tbContentName.Text)
    
    tvContent.LoadContent(ringtones.ToList());
