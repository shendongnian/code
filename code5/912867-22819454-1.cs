    StringBuilder s = new StringBuilder();
    s.AppendLine("Nick-Name\tCategory\tWeb-Pages\tICQ\tSkype\tMail\tPhone");
    for (int i = 0; i < listOfUsers.Count; i+=3)
    {
       s.AppendLine(
            nickName[i]  + "\t"
          + category[i]  + "\t"
          + webList[i]   + "\t"
          + ICQList[i]   + "\t"
          + skypeList[i] + "\t"
          + mailList[i]  + "\t"
          + phoneList[i]);;
    }
