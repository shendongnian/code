    public ActionResult Create()
        {
            using (var context = new material_managementEntities())
            {
                var blogId = (from cs in context.GROUP_MASTER
                             where cs.GROUP_NAME == "MIC"
                             select cs.ID).FirstOrDefault();
    
                DashboardModel dashboardModel= new DashboardModel();
                dashboardModel.transation.GROUP_MASTER_ID = blogId;
                dashboardModel.transation.GROUP_NAME = "MIC";
                dashboardModel.directoryMaster = (db.DIRECTORY_MASTER.Include(d => d.CATEGORY_MASTER).Include(d => d.REPRESENTATIVE_MASTER));           
                return View(dashboardModel);
            }
    
        }
