        /// <summary>
        /// Returns the public set accessor for this property.
        /// </summary>
        /// 
        /// <returns>
        /// The MethodInfo object representing the Set method for this property if the set accessor is public, or null if the set accessor is not public.
        /// </returns>
        [__DynamicallyInvokable]
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public MethodInfo GetSetMethod()
        {
          return this.GetSetMethod(false);
        }
        /// <summary>
        /// When overridden in a derived class, returns the set accessor for this property.
        /// </summary>
        /// 
        /// <returns>
        /// Value Condition A <see cref="T:System.Reflection.MethodInfo"/> object representing the Set method for this property. The set accessor is public.-or- <paramref name="nonPublic"/> is true and the set accessor is non-public. null<paramref name="nonPublic"/> is true, but the property is read-only.-or- <paramref name="nonPublic"/> is false and the set accessor is non-public.-or- There is no set accessor.
        /// </returns>
        /// <param name="nonPublic">Indicates whether the accessor should be returned if it is non-public. true if a non-public accessor is to be returned; otherwise, false. </param><exception cref="T:System.Security.SecurityException">The requested method is non-public and the caller does not have <see cref="T:System.Security.Permissions.ReflectionPermission"/> to reflect on this non-public method. </exception>
        [__DynamicallyInvokable]
        public abstract MethodInfo GetSetMethod(bool nonPublic);
        [__DynamicallyInvokable]
        public virtual MethodInfo SetMethod
        {
          [__DynamicallyInvokable, TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
          {
            return this.GetSetMethod(true);
          }
        }
