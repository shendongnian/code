    private static bool IsValidEmailAddress(string emailAddress)
    {
        return new System.ComponentModel.DataAnnotations
                            .EmailAddressAttribute()
                            .IsValid(emailAddress);
    }
