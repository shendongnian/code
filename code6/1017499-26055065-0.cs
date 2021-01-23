       public class GetMapCoordinates : SimplePage, IHttpHandler
        {
            public override void ProcessRequest(HttpContext context)
            {
                PropertyCriteriaCollection criterias = new PropertyCriteriaCollection();
                PropertyCriteria criteria = new PropertyCriteria();
                criteria.Condition = CompareCondition.Equal;
                criteria.Name = "PageTypeID";
                criteria.Type = PropertyDataType.PageType;
                criteria.Value = Locate.ContentTypeRepository().Load("HotelDetailPage").ID.ToString();
                criteria.Required = true;
    
                criterias.Add(criteria);
    
                PageDataCollection _newsPageItems = Locate.PageCriteriaQueryService().FindPagesWithCriteria(PageReference.StartPage, criterias);
            }
    
            public new bool IsReusable
            {
                get
                {
                    return false;
                }
            }
        }
