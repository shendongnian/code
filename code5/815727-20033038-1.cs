    using System.Linq;
    ...
    /* your list of hardcoded employees */
    list<object> listEmployees = your_list;
    /* Sort the list by using linq and save it as sortedEmployees
       The Sorting is done based on the property ID */
    list<object> sortedEmployees = listEmployees.OrderByDescending(t => t.ID);
    /* set the datasource of your gridview */
    GridView1.DataSource = sortedEmployees;
    ...
