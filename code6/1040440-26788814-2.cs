    public static ResponseObjectA getClients(RequestObjectA request) {
        return get(request, ServiceClass.GetClients);
    }
    public static ResponseObjectB getVendors(RequestObjectB request) {
        return get(request, ServiceClass.GetVendors);
    }
