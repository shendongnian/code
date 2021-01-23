    public static Expression<Func<Client, ClientDto>> Client2ClientDto()
    {
        var addr = AddressDto.Address2AddressDto()
        return x => new ClientDto() {
            Id = x.Id,
            FullName = x.FullName,
            Address = addr.Invoke(x)
        };
    }
