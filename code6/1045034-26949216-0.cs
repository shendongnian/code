    using System.Collections.Generic;
    using System;
    using System.Linq;
    
    IEnumerable<Type> getAllTheTypes() {
        return AppDomain.CurrentDomain.GetAssemblies().SelectMany(ass => ass.GetTypes());
    }
    IEnumerable<Type> getPluginTypes<T>() where T : IPlugin {
        return getAllTheTypes()
            .Where(typeof(T).IsAssignableFrom);
    }
    IEnumerable<Type> getPluginClassesWithDefaultConstructor<T>() where T : IPlugin {
        return getPluginTypes<T>()
            .Where(cls => !cls.IsAbstract)
            .Where(cls => cls.GetConstructor(new Type[] { }) != null);
    }
