    AddHandler Loaded,
        Sub(sender As Object, e As DbConfigurationLoadedEventArgs)
            e.ReplaceService(Of DbProviderServices)(
                Function(serviceInterceptor As DbProviderServices, o As Object)
                    Return New CachingProviderServices(serviceInterceptor, transactionHandler, New DefaultCachingPolicy())
                End Function)
        End Sub
