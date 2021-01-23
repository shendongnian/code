    using System.Linq;
    
    Department data = ...something...;
    var names = string.Join(
        ", ",
        data.People.Select(x => string.Format("{0} {1}", x.FirstName, x.LastName))
    );
