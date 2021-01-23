    if (optionalVisible && additionalVisible)
    {
        //hide rptAdditionalCosts footer
        //and
        //hide rptPerBookingOptionalExtras header
        rptAdditionalCosts.FooterTemplate = new BindableTemplateBuilder();
        rptPerBookingOptionalExtras.HeaderTemplate = new BindableTemplateBuilder();
    }
