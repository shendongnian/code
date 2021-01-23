    IEnumerable<usp_GetTableRankingsResult> results;
    switch(viewType){
         case "overall":
             results = new List<usp_GetTableRankingsResults>();
             // fill results or use another implementation of IEnumerable or whatever...
             break;
          case "week":
             results = new List<usp_GetTableRankingsResultsByWeek>();
             // fill results or use another implementation of IEnumerable or whatever...
             break;
          case "day":
             results = new List<usp_GetTableRankingsResultsByDay>();
             // fill results or use another implementation of IEnumerable or whatever...
             break;
    }
