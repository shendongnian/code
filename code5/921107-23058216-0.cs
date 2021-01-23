    public List<TaskTree> getTaskTree(int IdTeam)
    {
        using (HRSSD_DATA context = new HRSSD_DATA())
        {
            List<TaskTree> ListAll = new List<TaskTree>();
    
            var person = context.AR_PERSON.Where(a => a.STATUS == "A" && a.CR_GROUP.REF == IdTeam).ToList();
            if (person != null)
            {
                foreach (var item in person)
                {
                    TaskTree FundList = new TaskTree();
                    FundList.id = item.REF;
                    FundList.name = item.FULL_NAME;
    
                    var task = context.TASK.Where(a => a.IdCurrentOfficer == item.REF && a.BASE_ENTITY_TYPE == 100 && a.OPEN_IND == 1 && a.ACTIVE_TASK == 1 && a.TEMPLATE_IND == 0 && a.TASK_STATUS_REF != 114).ToList();
    
                    if (task != null)
                    {
                        // Please check below line of code 
                        // I have assumed that 'FundList.children' is  'List<TaskTree>()'.
                        // If 'FundList.children' have difference datatype type then create that type of object
                        FundList.children lst = new List<TaskTree>();
    
                        foreach (var tasks in task)
                        {
                            TaskTree Fund = new TaskTree();
                            Fund.name = tasks.TASK_TITLE;
                            Fund.id = tasks.TASK_NO;
    
                            lst.Add(Fund);
    
                            FundList.children = lst;
    
                        }
                    }
                    ListAll.Add(FundList);
                }
            }
            return ListAll;
        }
    }
