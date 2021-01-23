    using System.Linq;
    //availableApartments will contain all available apartments
    var availableApartments = all.Except(list) 
    // Will get you the first item.
    var freeApartment = availableApartments.FirstOrDefault()
