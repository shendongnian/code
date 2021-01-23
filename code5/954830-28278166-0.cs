    <caching>
                    <profiles>
                        
                        <add extension=".js" policy="CacheUntilChange" kernelCachePolicy="DontCache" />
                        <add extension=".css" policy="CacheUntilChange" kernelCachePolicy="DontCache" />
                       
                    </profiles>
                </caching>
        		<staticContent>
        			<clientCache cacheControlCustom="public" 
                cacheControlMode="UseMaxAge"
                cacheControlMaxAge="14.00:00:00" />
        		</staticContent>
