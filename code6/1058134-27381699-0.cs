        int fCount = Directory.GetFiles(path, "*.xml", SearchOption.AllDirectories).Length;
        for(int i = 0;i<fCount;i++){
            
            ...
            if(txtFirstName.Text == loginAcc.firstName && txtLastName.Text == loginAcc.lastName){
                return true;
            }
            else{
                return false;
            }
            return false;
        }
