    ''' <summary>
    ''' ProxyTypes of Gecko webbrowser.
    ''' </summary>
    Public Enum ProxyType
        ''' <summary>
        ''' Direct connection, no proxy. 
        ''' (Default in Windows and Mac previous to 1.9.2.4 /Firefox 3.6.4) 
        ''' </summary>
        DirectConnection = 0
        ''' <summary>
        ''' Manual proxy configuration.
        ''' </summary>
        Manual = 1
        ''' <summary>
        ''' Proxy auto-configuration (PAC).
        ''' </summary>
        AutoConfiguration = 2
        ''' <summary>
        ''' Auto-detect proxy settings.
        ''' </summary>
        AutoDetect = 4
        ''' <summary>
        ''' Use system proxy settings. 
        ''' (Default in Linux; default for all platforms, starting in 1.9.2.4 /Firefox 3.6.4)
        ''' </summary>
        System = 5
    End Enum
    ''' <summary>
    ''' Sets the proxy type of a Gecko Webbrowser.
    ''' </summary>
    ''' <param name="ProxyType">Indicates the type of proxy.</param>
    Private Sub SetGeckoProxyType(ByVal ProxyType As ProxyType)
        GeckoPreferences.Default("network.proxy.type") = ProxyType
    End Sub
    ''' <summary>
    ''' Sets the proxy of a Gecko Webbrowser.
    ''' </summary>
    ''' <param name="Host">Indicates the proxy host.</param>
    ''' <param name="Port">Indicates the proxy port.</param>
    Private Sub SetGeckoProxy(ByVal Host As String,
                              ByVal Port As Integer)
        ' Set the ProxyType to manual configuration.
        GeckoPreferences.Default("network.proxy.type") = ProxyType.Manual
        ' Set the HTP proxy Host and Port.
        GeckoPreferences.Default("network.proxy.http") = Host
        GeckoPreferences.Default("network.proxy.http_port") = Port
        ' Set the SSL proxy Host and Port.
        GeckoPreferences.Default("network.proxy.ssl") = Host
        GeckoPreferences.Default("network.proxy.ssl_port") = Port
    End Sub
