    public static DateTime ConvertFromExcelDate(int excelDate)
    {
        if (excelDate > 59) excelDate--; // 59 == februari 29
        return (new DateTime(1899,12,31)).AddDays(excelDate); // 19000101 == 1, so 18991231 == 0
    }
