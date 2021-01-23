    [TableColumnAttribute("areaCode")]
    [ProcedureParamAttribute("@areaCode", SqlDbType.Int)]
    [Display(Name = CommonMessages.ConstAreaCode)]
    //[StringLength(72, ErrorMessage=CommonMessages.ConstErrorMsgStringMaxSizeReached)]
    public int areaCode { get; set; }
