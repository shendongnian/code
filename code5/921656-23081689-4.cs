    <?xml version="1.0" encoding="utf-8"?>
    <extension xmlns="urn:newrelic-extension">
        <instrumentation>
            <tracerFactory name="NewRelic.Agent.Core.Tracer.Factories.BackgroundThreadTracerFactory" metricName="Background/CustomTransaction">
              <match assemblyName="ConsoleApplication1" className="ConsoleApplication1.CustomTransaction">
                <exactMethodMatcher methodName="StartTransaction" />
              </match>
            </tracerFactory>
            <tracerFactory metricName="Custom/Dummy">
              <match assemblyName="ConsoleApplication1" className="ConsoleApplication1.CustomTransaction">
                <exactMethodMatcher methodName="Dummy" />
              </match>
            </tracerFactory>
        </instrumentation>
    </extension>
