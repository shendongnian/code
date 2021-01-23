    if (!Page.IsPostBack)
    {
      Session.RemoveAll();
      DateTime today = DateTime.Today;
      string[] strArray = Strings.Split(Conversions.ToString(today), "/", -1, CompareMethod.Binary);
      if(strArray.Length >= 5)
      {
          int num1 = checked (Convert.ToInt32(strArray[4]) - 4);
          DropDownList ddlYear = _ddlYear;
          ddlYear.Items.Clear();
          int num2 = (int) checked ((short) num1);
          short num3 = checked ((short) (num1 + 6));
          for (short index = (short) num2; (int) index <= (int) num3; ++index)
            ddlYear.Items.Add(Conversions.ToString((int) index));
          ddlYear.DataBind();
          ddlYear.SelectedValue = Conversions.ToString((int) Convert.ToInt16(DateTime.Now.Year));
          LoadDept();
          Session.Add("rno", (object) 0);
          Session["rno"] = (object) new Random().Next();
          Rno = Conversions.ToInteger(Session["rno"]);
      }
    }
