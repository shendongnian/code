        // using System.Linq;
        typeof(Employee).GetProperties().Select(p => p.Name).ToArray()
*       
        // using System;
        Array.ConvertAll(typeof(Employee).GetProperties(), p => p.Name)
