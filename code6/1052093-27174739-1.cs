    public class StateVersion
    {
        public string StateShortName;
        public DateTime Date;
    }
    var stateVersions = new List<StateVersion>
    {
        new StateVersion { StateShortName = "AK", Date = new DateTime(2014, 11, 27)},
        new StateVersion { StateShortName = "AL", Date = new DateTime(2014, 11, 27)},
        new StateVersion { StateShortName = "HI", Date = new DateTime(2014, 11, 30)}
    };
    var aggStates = stateVersions.GroupBy(sv => sv.Date.ToShortDateString())
        .Select(g => String.Join(",", g.Select(x => x.StateShortName)) + " " + g.Key)
        .ToList();
    foreach (var s in aggStates)
    {
        Debug.WriteLine(s);
    }
