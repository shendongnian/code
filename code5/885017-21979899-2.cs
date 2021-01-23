    Worker.UserRepository.Update(user, // Entity to update
        user.BusinessModels, // Many-to-many relationship to update
        Worker.BusinessModelRepository.Get(), // Full set
        "BusinessModels", // Property name
        u => u.UserId == user.UserId); // Filter to get entity
