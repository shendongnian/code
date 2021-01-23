    <system.serviceModel>
        <extensions>
          <behaviorExtensions>
            <add name="ServiceBehavior" type="Namespace.UnderstandBehavior"/>
          </behaviorExtensions>
        </extensions>
        <behaviors>
              <serviceBehaviors>
                <behavior name="ServiceBehavior"></behavior>
              </serviceBehaviors>
        </behaviors>
    </system.serviceModel>
