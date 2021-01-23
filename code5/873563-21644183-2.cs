    listView1.Items.Add("");
    ListViewItem nyek = new ListViewItem();
    nyek.SubItems.Add("Second Honor");
    listView1.Items.Add(nyek);
    int yet = 0;
    foreach (int fed in idr2)
    {
    if(!idr1.Contains(fed))
    {
     if (rcs2[yet] >= 88)
     {
      ListViewItem gtbs = new ListViewItem();
      conek.OPEN("select concat(l_name,', ',f_name,' ',ucase(substring(m_name,1,1)),'.')     from students where stud_id ='" + fed + "'");
      while (conek.reader.Read())
      {
      gtbs.SubItems.Add(conek.reader.GetString(0));
      }
      conek.CLOSE();
       foreach (int gfa in clsid)
       {
       conek.OPEN("select tmp_gr1 from class_info left join students on class_info.stud_id     = students.stud_id where class_info.stud_id = '" + fed + "' and class_id = '" + gfa + "'     ");
       while (conek.reader.Read())
       {
        gtbs.SubItems.Add(Math.Round(conek.reader.GetDouble(0), 2).ToString());
       }
      conek.CLOSE();
     }
     gtbs.SubItems.Add(Math.Round(rcs2[yet], 2).ToString());
     yet++;
     listView1.Items.AddRange(new ListViewItem[] { gtbs });
      }
     }
    }
