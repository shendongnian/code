    public static PropertyCompliance PropertyIsCompliant(this IEnumerable<PropertyCompliance> complianceRecords, DateTime checkDate) {
        return complianceRatings
             .OrderByDescending(cr => cr.Date)
             .First(cr => cr.Date <= checkDate);
    }
