    private Main_uc main_uc = null;
    
    private Control CreateControl(ControlsEnum ctrl)
    {
      Control ret = null;
    
      switch (ctrl)
      {
        case ControlsEnum.CATEGORY_CONTROL:
        {
          if(main_uc != null)
          {
            ret = new Categoty_uc();
            ((Categoty_uc)ret).ButtonClicked += (sender, e) => 
                              {main_uc.datagridview_Refresh();}
          }
          else
          {
            throw new Exception("Create Main_uc first!");
          }
        }
        break;
        case ControlsEnum.MAIN_CONTROL:
        {
          if(main_uc == null)
          {
            main_uc = new Main_uc();
          }
          ret = main_uc;
        }
      }
        
      return ret;
    }
