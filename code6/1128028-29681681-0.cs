    public ActionResult Delete(PlanningViewParam data)
    {
        List<PointData> Points = UserSession.GetValue(
            StateNameEnum.Planning, 
            ScreenName.Planning.ToString() + "Points" + data.ViewType,
            UserSessionMode.Database) as List<PointData>;
    
        Points=Points.Where(p=>p.pointNumber!=data.Number).ToList();
    
    }
