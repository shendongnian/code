    public void Level1Member()
    {
        RunLevel2Member();
        RunAnotherLevel2Member();
    }
        private void RunLevel2Member()
        {
            RunLevel3Member();
        }
            
            private void RunLevel3Member()
            {
                //....
            }
        private void RunAnotherLevel2Member()
        {
            //..
        }           
