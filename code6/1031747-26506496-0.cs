    if (usvm.EstablishmentId > 0)
        query = query.Where(x => x.UserEstablishments
            .Any(y => y.UserEstablishmentId == usvm.EstablishmentId));
    if (usvm.OrganisationId > 0)
        query = query.Where(x => x.UserEstablishments
            .Any(y => y.Establishment.OrganisationId == usvm.OrganisationId));
