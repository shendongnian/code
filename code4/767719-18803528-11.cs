    <system.web>		
		<caching>
			<outputCache defaultProvider="MyCache">
				<providers>
					<add name="MyCache" type="MyApp.Namespace.MyOutputCacheProvider"/>
				</providers>
			</outputCache>
		</caching>
    </system.web>
