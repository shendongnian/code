    Public Sub Configure(app As IAppBuilder)
        Dim act = Sub(config As IBootstrapperConfiguration)
                    config.UseSqlServerStorage("<...>")
                    config.UseServer();
                  End Sub
        app.UseHangfire(act)
    End Sub
