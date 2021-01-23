    // This way, when clicked, the command will point to the correct submenu
    public Window1ViewModel()
            {
                SubMenus = MenuDefinition.GetSubMenus();
    
                foreach(SubMenuViewModel submenu in SubMenus){
                    string Temp=submenu.SubMenuName
                    submenu.CommandSubMenu=new RelayCommand(()=>clickedSubMenu(Temp));
                }
            }
    
