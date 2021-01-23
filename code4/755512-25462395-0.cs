    private void Call(object e)
    {
        ContactPhone phone = null;
        var kind = e as string;
        switch (kind)
        {
            case "Mobile":
                {
                    phone = SelectedContact.Phones.Where(p => p.Kind == ContactPhoneKind.Mobile).FirstOrDefault();
                    break;
                }
            case "Work":
                {
                    phone = SelectedContact.Phones.Where(p => p.Kind == ContactPhoneKind.Work).FirstOrDefault();
                    break;
                }
    }
