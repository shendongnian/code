    // This way, when clicked, the command will always point to the last submenu from the loop
    public Window1ViewModel()
            {
                SubMenus = MenuDefinition.GetSubMenus(); 
                    
                foreach(SubMenuViewModel submenu in SubMenus){
                    submenu.CommandSubMenu=new RelayCommand(()=>clickedSubMenu(submenu.SubMenuName));
                }
            }
