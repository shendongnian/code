C#
        using (var coatsService = _factory.CreateCoatsService())
        {
            var cls = coatsService.GetPrdedtxts(_path);
            return cls.ToList();
        }
VB
        Using coatsService = _factory.CreateCoatsService()
	        Dim cls = coatsService.GetPrdedtxts(_path)
            return cls.ToList()
        End Using
